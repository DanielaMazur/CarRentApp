import { useCarRentAppContext } from "context/useCarRentAppContext";
import { AccountService } from "services";
import { login } from "services/authProvider";

import { Authentication, Form } from "components";

import { Account } from "types";

const SignUp = () => {
  const {
    handlers: { addSnackbar },
  } = useCarRentAppContext();

  const handleSignUp = async (credentials: Account.Account) => {
    try {
      await AccountService.SignUp(credentials);

      const { accessToken } = await AccountService.SignIn(credentials);

      login({ accessToken });
    } catch (error) {
      addSnackbar({
        status: "error",
        message: error.message,
      });
    }
  };

  return (
    <Authentication isSignIn={false}>
      <Form.SignUp handleFormSubmit={handleSignUp} />
    </Authentication>
  );
};

export { SignUp };
