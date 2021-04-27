import { AppBar, Toolbar, Button, Typography } from "@material-ui/core";
import { useHistory } from "react-router";

import { useStyles } from "./navbar.styles";

const Navbar = () => {
  const history = useHistory();
  const classes = useStyles();

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
        <Button color="inherit" className={classes.loginButton}>
          Login
        </Button>
      </Toolbar>
    </AppBar>
  );
};

export { Navbar };
