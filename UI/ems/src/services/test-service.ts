export function http(request: string): Promise<any> {
    return fetch(request)
    .then(data => data.json())
  }