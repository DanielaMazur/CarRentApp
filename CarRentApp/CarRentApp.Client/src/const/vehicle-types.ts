import Cabriolet from "assets/images/cabriolet.jpg";
import Hatchback from "assets/images/hatchback.jpg";
import Minivan from "assets/images/minivan.jpg";
import Sedan from "assets/images/sedan.jpg";
import Suv from "assets/images/suv.jpg";
import Pickup from "assets/images/pickup.jpg";

import { Filters } from "types";

const VEHICLE_TYPES: Record<Filters.CarBodyFiltersType, { icon: string }> = {
  Cabriolet: {
    icon: Cabriolet,
  },
  Hatchback: {
    icon: Hatchback,
  },
  Minivan: {
    icon: Minivan,
  },
  Sedan: {
    icon: Sedan,
  },
  Suv: {
    icon: Suv,
  },
  PickUp: {
    icon: Pickup,
  },
  Micro: {
    icon: Suv,
  },
  Cuv: {
    icon: Suv,
  },
  Coupe: {
    icon: Suv,
  },
  Roadster: {
    icon: Suv,
  },
  Van: {
    icon: Suv,
  },
  Limousine: {
    icon: Suv,
  },
  Camervan: {
    icon: Suv,
  },
};

export { VEHICLE_TYPES };
