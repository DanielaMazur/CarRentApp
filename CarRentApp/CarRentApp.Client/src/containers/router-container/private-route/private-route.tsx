import { RouteProps, Route } from "react-router";

const PrivateRoute: React.FC<RouteProps> = (props) => {
  return <Route {...props} />;
};

export { PrivateRoute };
