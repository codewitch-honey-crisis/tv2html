using System.Collections;
using System.Dynamic;
using System.Text;
using System.Text.Json;

class TmdbElement : DynamicObject, IEnumerable<object?>
{
	JsonElement _inner;
	private static object? ElemToObj(JsonElement elem)
	{
		object? result = null;
		switch (elem.ValueKind)
		{
			case JsonValueKind.String:
				result = elem.GetString()!;
				break;
			case JsonValueKind.Number:
				result = elem.GetDouble();
				break;
			case JsonValueKind.Null:
				result = null;
				break;
			case JsonValueKind.True:
				result = true; break;
			case JsonValueKind.False:
				result = false; break;
			case JsonValueKind.Object:
			case JsonValueKind.Array:
				result = new TmdbElement(elem);
				break;
			default:
				result = null;
				break;
		}
		return result;
	}
	public TmdbElement(JsonElement json)
	{
		_inner = json;

	}
	public int Count
	{
		get
		{
			if (_inner.ValueKind == JsonValueKind.Array)
			{
				return _inner.GetArrayLength();
			}
			throw new NotSupportedException();
		}
	}
	public object? this[int index]
	{
		get
		{
			if (_inner.ValueKind == JsonValueKind.Array)
			{
				return ElemToObj(_inner[index]);
			}
			throw new NotSupportedException();
		}
	}
	public override bool TryGetMember(
		GetMemberBinder binder, out object? result)
	{
		JsonElement elem;
		if (_inner.TryGetProperty(binder.Name, out elem))
		{
			result = ElemToObj(elem);
			return true;
		}
		result = null;
		return false;
	}

	public override bool TrySetMember(
		SetMemberBinder binder, object? value)
	{
		return false;
	}

	public IEnumerator<object?> GetEnumerator()
	{
		if (_inner.ValueKind == JsonValueKind.Array)
		{
			foreach (var elem in _inner.EnumerateArray())
			{
				yield return ElemToObj(elem);
			}
		}
		else
		{
			throw new NotSupportedException();
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}

internal static class Tmdb
{
	static HttpClient _client = new HttpClient();
	public static string AuthToken
	{
		get; set;
	} = "";
	public static string GetSafePath(string path)
	{
		var segs = path.Split(new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar });
		if (segs.Length == 0)
		{
			return "";
		}
		var result = segs[0];
		var inv = Path.GetInvalidPathChars();
		var sb = new StringBuilder();
		for (int i = 1; i < segs.Length; i++)
		{
			sb.Clear();
			var seg = segs[i];
			for (int j = 0; j < seg.Length; j++)
			{
				if (Array.IndexOf(inv, seg[j]) > -1)
				{
					sb.Append('_');
				}
				else
				{
					sb.Append(seg[j]);
				}
			}
			result = Path.Combine(result, sb.ToString());
		}
		return result;
	}
	public static JsonDocument GetJson(string url)
	{
		JsonDocument result;
		using (var msg = new HttpRequestMessage(HttpMethod.Get, url))
		{
			msg.Headers.Clear();
			msg.Headers.Add("accept", "application/json");
			msg.Headers.Add("Authorization", "bearer " + AuthToken);
			using (var resp = _client.Send(msg))
			{
				result = JsonDocument.Parse(resp.Content.ReadAsStream());

			}
		}
		return result;
	}
	public static void Download(string url,string path, bool overwrite = false)
	{
		if (overwrite || !File.Exists(path))
		{
			using (var msg = new HttpRequestMessage(HttpMethod.Get, url))
			{
				using (var resp = _client.Send(msg))
				{
					var dir = Path.GetDirectoryName(path);
					if(!Directory.Exists(dir))
					{
						Directory.CreateDirectory(dir!);
					}
					using (var outstm = File.OpenWrite(path))
					{
						resp.Content.ReadAsStream().CopyTo(outstm);
					}

				}
			}
		}
	}
	public static object GetObject(string url)
	{
		return new TmdbElement(GetJson(url).RootElement);
	}
}
