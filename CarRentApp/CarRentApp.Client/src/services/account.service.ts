import { API } from "./api";

import { Account } from "types";

const SignUp = (account: Account.Account) => {
  return API.post<Account.AccountToken>("/account/register", account);
};

const AccountService = { SignUp };

export { AccountService };
