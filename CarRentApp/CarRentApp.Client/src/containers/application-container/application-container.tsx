import { ReactNode, useCallback, useEffect } from "react";

import { useCarRentAppContext } from "context/useCarRentAppContext";
import { UserService } from "services";
import { useAuth } from "services/authProvider";

import { Navbar, Snackbar, Footer } from "components";

const ApplicationContainer = (props: { children: ReactNode }) => {
  const [isLoggedIn] = useAuth();

  const {
    snackbars,
    handlers: { setUser },
  } = useCarRentAppContext();

  const fetchUser = useCallback(async () => {
    try {
      const user = await UserService.GetCurrentUser();

      setUser(user);
    } catch (error) {
      console.log(error);
    }
  }, [setUser]);

  useEffect(() => {
    if (isLoggedIn) {
      fetchUser();
    }
  }, [fetchUser, isLoggedIn]);

  return (
    <>
      <Navbar />
      {props.children}
      {snackbars.map((snackbar) => (
        <Snackbar key={snackbar.id} {...snackbar} />
      ))}
      <Footer />
    </>
  );
};

export { ApplicationContainer };
