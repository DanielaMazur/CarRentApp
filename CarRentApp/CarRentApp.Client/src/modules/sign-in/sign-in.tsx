import { useHistory } from "react-router";
import { useEffect } from "react";

import { UserService } from "services";
import { useCarRentAppContext } from "context/useCarRentAppContext";
import { login, useAuth } from "services/authProvider";

import { Authentication, Form } from "components";

import { User } from "types";

const SignIn = () => {
  const history = useHistory();

  const [isUserAuth] = useAuth();

  const {
    handlers: { addSnackbar },
  } = useCarRentAppContext();

  const handleSignIn = async (credentials: User.SignInUser) => {
    try {
      const { accessToken } = await UserService.SignIn(credentials);

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

  useEffect(() => {
    if (isUserAuth) {
      history.push("/");
    }

    //eslint-disable-next-line
  }, []);

  return (
    <Authentication isSignIn>
      <Form.SignIn handleFormSubmit={handleSignIn} />
    </Authentication>
  );
};

export { SignIn };
