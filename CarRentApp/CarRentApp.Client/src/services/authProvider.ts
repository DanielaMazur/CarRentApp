import { createAuthProvider } from "react-token-auth";

const [useAuth, authFetch, login, logout] = createAuthProvider<{
  accessToken: string;
}>({
  accessTokenKey: "accessToken",
});

export { useAuth, authFetch, login, logout };
