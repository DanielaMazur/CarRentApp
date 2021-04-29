import { Account } from "types";

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

const AccountService = { SignUp };

export { AccountService };
