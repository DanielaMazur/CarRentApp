import { Grid, Typography, Box, Button } from "@material-ui/core";
import { useHistory } from "react-router";

import { VEHICLE_TYPES } from "const";

import { useStyles } from "./vehicle-section.styles";

const VehiclesSection = () => {
  const classes = useStyles();
  const history = useHistory();

  const handleShowAllVehicles = () => history.push("/cars");

  return (
    <Box display="flex" flexDirection="column" p="10px">
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
          <Grid
            item
            key={car.name}
            sm={4}
            xs={6}
            onClick={() => history.push("/cars")}
          >
            <Box className={classes.carTypeContainer}>
              <img src={car.icon} alt="carIcon" className={classes.carImage} />
              <Typography variant="subtitle1" className={classes.carName}>
                {car.name}
              </Typography>
            </Box>
          </Grid>
        ))}
      </Grid>

      <Button
        className={classes.showAllCarsButton}
        variant="contained"
        color="primary"
        onClick={handleShowAllVehicles}
      >
        Show All Cars
      </Button>
    </Box>
  );
};

export { VehiclesSection };
