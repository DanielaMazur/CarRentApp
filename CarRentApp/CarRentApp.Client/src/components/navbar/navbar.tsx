import { AppBar, Toolbar, Button, Typography } from "@material-ui/core";

import { useStyles } from "./navbar.styles";

const Navbar = () => {
  const classes = useStyles();

  return (
    <AppBar position="static">
      <Toolbar>
        <Typography variant="h5" className={classes.logo}>
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
