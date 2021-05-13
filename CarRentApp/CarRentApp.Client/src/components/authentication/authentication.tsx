import { useCallback, useEffect, useState } from "react";
import { Paper, Grid, Avatar, Typography } from "@material-ui/core";

import { Link } from "react-router-dom";

import { ReactNode } from "react";

import { unsplash } from "services";
import { useCarRentAppContext } from "context/useCarRentAppContext";

import { useStyles } from "./authentication.styles";

export type AuthenticationProps = {
  isSignIn: boolean;

  children: ReactNode;
};

const Authentication = (props: AuthenticationProps) => {
  const [imageUrl, setImageUrl] = useState<string | undefined>();

  const classes = useStyles({ imageUrl });

  const {
    handlers: { addSnackbar },
  } = useCarRentAppContext();

  const fetchImage = useCallback(async () => {
    try {
      const image = await unsplash.photos.getRandom({ query: "automobile" });

      setImageUrl(image.response?.urls?.regular);
    } catch (error) {
      addSnackbar({ status: "error", message: error.message });
    }
  }, [addSnackbar]);

  useEffect(() => {
    fetchImage();
  }, [fetchImage]);

  return (
    <Grid container component="main" className={classes.root}>
      <Grid item xs={false} sm={4} md={7} className={classes.image} />
      <Grid item xs={12} sm={8} md={5} component={Paper} elevation={6} square>
        <div className={classes.paper}>
          <Avatar className={classes.avatar} />
          <Typography component="h1" variant="h5">
            {props.isSignIn ? "Sign In" : "Sign Up"}
          </Typography>

          {props.children}

          <Typography>
            {props.isSignIn
              ? "Don't have an account yet? "
              : "Already have an account? "}
            <Link to={props.isSignIn ? "/sign-up" : "/sign-in"}>
              {props.isSignIn ? "Sign Up" : "Sign In"}
            </Link>
          </Typography>
        </div>
      </Grid>
    </Grid>
  );
};

export { Authentication };
