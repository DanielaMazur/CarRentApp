import { User } from "types";
import { authFetch } from "./authProvider";

import { fetchApi } from "./fetchApi";

const SignUp = (user: User.User) => {
  return fetchApi<string | {}>("/user/register", {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify(user),
  });
};

const SignIn = (user: User.SignInUser) => {
  return fetchApi<User.UserToken>("/user/login", {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify(user),
  });
};

const GetCurrentUser = () => {
  return authFetch<User.User>("/user");
};

const UserService = { SignUp, SignIn, GetCurrentUser };

export { UserService };
