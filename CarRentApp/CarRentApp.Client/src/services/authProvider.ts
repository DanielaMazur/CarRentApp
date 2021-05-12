import { createAuthProvider } from "react-token-auth";

const [useAuth, RTAauthFetch, login, logout] = createAuthProvider<{
  accessToken: string;
}>({
  accessTokenKey: "accessToken",
});

const authFetch = <TResponse>(
  url: string,
  config: RequestInit = {}
): Promise<TResponse> =>
  RTAauthFetch(`https://localhost:44359/api${url}`, config)
    .then((response) => response.json())
    .then((data) => data);

export { useAuth, authFetch, login, logout };
