import { ReactNode, useCallback, useEffect } from "react";
import { useLocation } from "react-router";

import { useCarRentAppContext } from "context/useCarRentAppContext";
import { AccountService } from "services";
import { useAuth } from "services/authProvider";

import { Navbar, Snackbar, Footer } from "components";

const AUTHENTICATION_PATHS = ["/sign-in", "/sign-up"];

const ApplicationContainer = (props: { children: ReactNode }) => {
  const location = useLocation();

  const [isLoggedIn] = useAuth();

  const {
    snackbars,
    handlers: { setUser },
  } = useCarRentAppContext();

  const hideSidebar = AUTHENTICATION_PATHS.some((path) =>
    location.pathname.includes(path)
  );

  const fetchUser = useCallback(async () => {
    try {
      const user = await AccountService.GetCurrentAccount();

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
      {!hideSidebar && <Navbar />}
      {props.children}
      {snackbars.map((snackbar) => (
        <Snackbar key={snackbar.id} {...snackbar} />
      ))}
      <Footer />
    </>
  );
};

export { ApplicationContainer };
