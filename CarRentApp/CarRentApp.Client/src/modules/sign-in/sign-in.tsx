import { useHistory } from "react-router";

import { AccountService } from "services";
import { useCarRentAppContext } from "context/useCarRentAppContext";
import { login } from "services/authProvider";

import { Authentication, Form } from "components";

import { Account } from "types";

const SignIn = () => {
  const history = useHistory();

  const {
    handlers: { addSnackbar },
  } = useCarRentAppContext();

  const handleSignIn = async (credentials: Account.SignInAccount) => {
    try {
      const { accessToken } = await AccountService.SignIn(credentials);

      if (accessToken == null) {
        throw Error("Sign In Failed!");
      }

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

  return (
    <Authentication isSignIn>
      <Form.SignIn handleFormSubmit={handleSignIn} />
    </Authentication>
  );
};

export { SignIn };
