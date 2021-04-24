import { Grid, Typography, Box } from "@material-ui/core";

import { VEHICLE_TYPES } from "const";

import { useStyles } from "./vehicle-section.styles";

const VehiclesSection = () => {
  const classes = useStyles();

  return (
    <Box>
      <Typography
        variant="h3"
        color="secondary"
        className={classes.sectionTitle}
      >
        Choose a vehicle type
      </Typography>
      <Grid
        container
        spacing={7}
        justify="center"
        className={classes.chooseCarSection}
      >
        {VEHICLE_TYPES.map((car) => (
          <Grid item key={car.name} xs={4}>
            <Box className={classes.carTypeContainer}>
              <img src={car.icon} alt="carIcon" className={classes.carImage} />
              <Typography variant="subtitle1" className={classes.carName}>
                {car.name}
              </Typography>
            </Box>
          </Grid>
        ))}
      </Grid>
    </Box>
  );
};

export { VehiclesSection };
