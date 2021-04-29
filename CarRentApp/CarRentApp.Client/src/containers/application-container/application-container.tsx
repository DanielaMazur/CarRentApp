import { ReactNode } from "react";
import { useLocation } from "react-router";

import { useCarRentAppContext } from "context/useCarRentAppContext";

import { Navbar, Snackbar } from "components";

const AUTHENTICATION_PATHS = ["/sign-in", "/sign-up"];

const ApplicationContainer = (props: { children: ReactNode }) => {
  const location = useLocation();

  const { snackbars } = useCarRentAppContext();

  const hideSidebar = AUTHENTICATION_PATHS.some((path) =>
    location.pathname.includes(path)
  );

  return (
    <>
      {!hideSidebar && <Navbar />}
      {props.children}
      {snackbars.map((snackbar) => (
        <Snackbar key={snackbar.id} {...snackbar} />
      ))}
    </>
  );
};

export { ApplicationContainer };
