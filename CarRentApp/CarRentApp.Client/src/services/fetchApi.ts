const fetchApi = <TResponse>(
  url: string,
  config: RequestInit = {}
): Promise<TResponse> =>
  fetch(`https://localhost:44359/api${url}`, config)
    .then((response) => response.text())
    .then((data) => (data ? JSON.parse(data) : {}));

export { fetchApi };
