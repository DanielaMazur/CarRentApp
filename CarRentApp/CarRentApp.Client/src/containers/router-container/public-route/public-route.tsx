import { Route, RouteProps } from "react-router";

const PublicRoute = (props: RouteProps) => {
  return <Route {...props} />;
};

export { PublicRoute };
