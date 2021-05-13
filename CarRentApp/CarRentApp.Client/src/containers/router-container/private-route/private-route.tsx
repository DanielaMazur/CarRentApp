import { RouteProps, Route, Redirect } from "react-router";

import { useAuth } from "services/authProvider";

const PrivateRoute = (props: RouteProps) => {
  const [isUserAuth] = useAuth();

  if (!isUserAuth) {
    return <Redirect to="/sign-in" />;
  }

  return <Route {...props} />;
};

export { PrivateRoute };
