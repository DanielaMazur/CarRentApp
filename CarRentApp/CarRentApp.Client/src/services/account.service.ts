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
  return authFetch<Account.Account>("/account");
};

const AccountService = { SignUp, SignIn, GetCurrentAccount };

export { AccountService };
