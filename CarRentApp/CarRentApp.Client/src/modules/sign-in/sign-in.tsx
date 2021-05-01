import { useHistory } from "react-router";

import { AccountService } from "services";
import { useCarRentAppContext } from "context/useCarRentAppContext";

import { Authentication } from "components";
import { login } from "services/authProvider";

import { Account } from "types";

const SignIn = () => {
  const history = useHistory();

  const {
    handlers: { addSnackbar },
  } = useCarRentAppContext();

  const handleSignIn = async (credentials: Account.Account) => {
    try {
      const { accessToken } = await AccountService.SignIn(credentials);

      login({
        accessToken,
      });

      history.push("/");
    } catch (error) {
      addSnackbar({
        status: "error",
        message: error.message,
      });
    }
  };

  return <Authentication isSignIn handleFormSubmit={handleSignIn} />;
};

export { SignIn };
