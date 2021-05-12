import { AppBar, Toolbar, Button, Typography, Box } from "@material-ui/core";
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

  return (
    <AppBar position="static">
      <Toolbar>
        <Typography
          variant="h5"
          className={classes.logo}
          onClick={() => history.push("/")}
        >
          CARENT
        </Typography>

        <Box ml="auto">
          {isAuthenticated ? (
            <Avatar name={user?.email || ""} />
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
