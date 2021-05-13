import {
  AppBar,
  Toolbar,
  Button,
  Typography,
  Box,
  IconButton,
} from "@material-ui/core";
import DateRangeIcon from "@material-ui/icons/DateRange";
import { useCarRentAppContext } from "context/useCarRentAppContext";
import { useHistory } from "react-router";

import { useAuth } from "services/authProvider";

import { Avatar } from "components";

import { useStyles } from "./navbar.styles";

const Navbar = () => {
  const history = useHistory();
  const classes = useStyles();

  const [isAuthenticated] = useAuth();
  const { user } = useCarRentAppContext();

  const handleReservationsClick = () => history.push("/reservations");

  return (
    <AppBar position="static">
      <Toolbar>
        <Typography
          variant="h5"
          className={classes.logo}
          onClick={() => history.push("/")}
        >
          CARRENT
        </Typography>

        <Box ml="auto">
          {isAuthenticated ? (
            <Box display="flex" alignItems="center">
              <IconButton
                aria-label="reservations"
                className={classes.reservationsButton}
                onClick={handleReservationsClick}
              >
                <DateRangeIcon className={classes.reservationsIcon} />
              </IconButton>
              <Avatar name={user?.email || ""} />
            </Box>
          ) : (
            <Button color="secondary" onClick={() => history.push("/sign-in")}>
              <b>Login</b>
            </Button>
          )}
        </Box>
      </Toolbar>
    </AppBar>
  );
};

export { Navbar };
