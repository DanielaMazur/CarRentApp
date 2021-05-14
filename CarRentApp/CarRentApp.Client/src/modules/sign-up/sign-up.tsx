import { useHistory } from "react-router";
import { useEffect } from "react";

import { useCarRentAppContext } from "context/useCarRentAppContext";
import { UserService } from "services";
import { login, useAuth } from "services/authProvider";

import { Authentication, Form } from "components";

import { User } from "types";

const SignUp = () => {
  const history = useHistory();

  const [isUserAuth] = useAuth();

  const {
    handlers: { addSnackbar },
  } = useCarRentAppContext();

  const handleSignUp = async (credentials: User.User) => {
    try {
      const response = await UserService.SignUp(credentials);

      if (typeof response == "string") {
        throw new Error(response);
      }

      const { accessToken } = await UserService.SignIn(credentials);

      login({ accessToken });

      history.goBack();
    } catch (error) {
      addSnackbar({
        status: "error",
        message: error.message,
      });
    }
  };

  useEffect(() => {
    if (isUserAuth) {
      history.push("/");
    }

    //eslint-disable-next-line
  }, []);

  return (
    <Authentication isSignIn={false}>
      <Form.SignUp handleFormSubmit={handleSignUp} />
    </Authentication>
  );
};

export { SignUp };
