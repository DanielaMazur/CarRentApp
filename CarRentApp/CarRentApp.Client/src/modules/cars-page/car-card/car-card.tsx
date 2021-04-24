import { Card, CardMedia, CardContent, Typography } from "@material-ui/core";

import { Car } from "types";

import { useStyles } from "./car-card.styles";

export type CarCardProps = {
  car: Car.Car;
};

const CarCard: React.FC<CarCardProps> = ({ car }) => {
  const classes = useStyles();

  return (
    <Card>
      <CardMedia
        className={classes.imageContainer}
        image={car.photos[0]?.path}
        title="Paella dish"
      />
      <CardContent>
        <Typography variant="h6" color="textSecondary">
          {car.brand} {car.model}
        </Typography>
        <Typography variant="body2" color="textSecondary" component="p">
          <b>Transmission:</b> {car.transmission}
        </Typography>
        <Typography variant="body2" color="textSecondary" component="p">
          <b>Doors:</b> {car.numberOfDoors}
        </Typography>
        <Typography variant="body2" color="textSecondary" component="p">
          <b>Price:</b> {car.pricePerDay}
        </Typography>
      </CardContent>
    </Card>
  );
};

export { CarCard };
