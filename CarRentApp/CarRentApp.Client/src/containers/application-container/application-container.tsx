import { ReactNode, useEffect } from "react";
import { useLocation } from "react-router";

import { useCarRentAppContext } from "context/useCarRentAppContext";

import { Navbar, Snackbar, Footer } from "components";
import { AccountService } from "services";

const AUTHENTICATION_PATHS = ["/sign-in", "/sign-up"];

const ApplicationContainer = (props: { children: ReactNode }) => {
  const location = useLocation();

  const {
    snackbars,
    handlers: { setUser, addSnackbar },
  } = useCarRentAppContext();

  const hideSidebar = AUTHENTICATION_PATHS.some((path) =>
    location.pathname.includes(path)
  );

  const fetchUser = async () => {
    try {
      const user = await AccountService.GetCurrentAccount();

      setUser(user);
    } catch (error) {
      addSnackbar({
        status: "error",
        message: error.message,
      });
    }
  };

  useEffect(() => {
    fetchUser();

    //eslint-disable-next-line
  }, []);

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
