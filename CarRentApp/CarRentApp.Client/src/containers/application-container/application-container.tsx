import { ThemeProvider } from "@material-ui/core";
import { useLocation } from "react-router";

import { Navbar } from "components";

import { theme } from "theme";

const AUTHENTICATION_PATHS = ["/sign-in", "/sign-up"];

const ApplicationContainer = () => {
  const location = useLocation();

  const hideSidebar = AUTHENTICATION_PATHS.some((path) =>
    location.pathname.includes(path)
  );

  return (
    <ThemeProvider theme={theme}>{!hideSidebar && <Navbar />}</ThemeProvider>
  );
};

export { ApplicationContainer };
