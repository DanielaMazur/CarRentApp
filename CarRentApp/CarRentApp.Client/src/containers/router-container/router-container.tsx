import { Switch } from "react-router";

import { modules } from "modules";

import { PrivateRoute } from "./private-route";
import { PublicRoute } from "./public-route";

const RouterContainer: React.FC = () => {
  return (
    <Switch>
      {modules.map((module) => {
        const RouteComponent = module.private ? PrivateRoute : PublicRoute;

        return <RouteComponent key={module.name} {...module} />;
      })}
    </Switch>
  );
};

export { RouterContainer };
