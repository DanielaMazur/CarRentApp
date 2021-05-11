import { Account } from "types";
import { authFetch } from "./authProvider";

import { fetchApi } from "./fetchApi";

const SignUp = (account: Account.Account) => {
  return fetchApi<Account.AccountToken>("/account/register", {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify(account),
  });
};

const SignIn = (account: Account.Account) => {
  return fetchApi<Account.AccountToken>("/account/login", {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify(account),
  });
};

const GetCurrentAccount = () => {
  return authFetch("https://localhost:44359/api/account");
};

// const GetCurrentAccount = () => {
//   return fetchApi("/account", {
//     headers: {
//       Authorization:
//         "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpYXQiOiIwOS4wNS4yMDIxIDE5OjE5OjU4IiwiZW1haWwiOiJkYW5pZWxhbWF6dXIyMDAwQGdtYWlsLmNvbSIsIlJvbGUiOiJDbGllbnQiLCJleHAiOjE2MjA2NzQzOTgsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzU5IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDozMDAwIn0.V5dNLTqWCf5m-5DdrhrYed4dzJ6aQMV8RJmnLLz7etM",
//     },
//   });
// };

const AccountService = { SignUp, SignIn, GetCurrentAccount };

export { AccountService };
