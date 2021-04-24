import { Route, RouteProps } from "react-router";

const PublicRoute: React.FC<RouteProps> = (props) => {
  return <Route {...props} />;
};

export { PublicRoute };
