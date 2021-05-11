import { ViewCarPage } from "./view-car-page";

const ViewCarModule = {
  name: "View Car Page",
  component: ViewCarPage,
  path: "/cars/:id",
  exact: true,
  private: false,
};

export { ViewCarModule };
