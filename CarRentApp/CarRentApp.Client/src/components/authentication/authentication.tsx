import { useCallback, useEffect, useMemo, useState } from "react";
import {
  Paper,
  Grid,
  Avatar,
  Typography,
  TextField,
  Button,
} from "@material-ui/core";
import { useForm, Controller } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";

import { unsplash } from "services";
import { useCarRentAppContext } from "context/useCarRentAppContext";

import { Account } from "types";

import { useStyles } from "./authentication.styles";
import { Link } from "react-router-dom";

const SignUpFormSchema = yup.object().shape({
  email: yup.string().email().required("Email is required"),
  password: yup.string().required("Password is required").min(8),
});

export type AuthenticationProps = {
  handleFormSubmit: (credentials: Account.Account) => void;
  isSignIn: boolean;
};

const Authentication = (props: AuthenticationProps) => {
  const [imageUrl, setImageUrl] = useState<string | undefined>();

  const classes = useStyles({ imageUrl });

  const {
    handlers: { addSnackbar },
  } = useCarRentAppContext();
  const { handleSubmit, control } = useForm({
    resolver: yupResolver(SignUpFormSchema),
    defaultValues: {
      email: "",
      password: "",
    },
  });

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
          <form
            className={classes.form}
            onSubmit={handleSubmit(props.handleFormSubmit)}
          >
            <Controller
              control={control}
              name="email"
              render={({
                field: { onChange, onBlur, value },
                fieldState: { invalid, error },
              }) => (
                <TextField
                  onChange={onChange}
                  onBlur={onBlur}
                  value={value}
                  error={invalid}
                  variant="outlined"
                  margin="normal"
                  id="email"
                  label="Email Address"
                  fullWidth
                  autoComplete="email"
                  autoFocus
                  helperText={error?.message}
                />
              )}
            />

            <Controller
              control={control}
              name="password"
              render={({
                field: { onChange, onBlur, value },
                fieldState: { invalid, error },
              }) => (
                <TextField
                  onChange={onChange}
                  onBlur={onBlur}
                  value={value}
                  error={invalid}
                  variant="outlined"
                  margin="normal"
                  required
                  fullWidth
                  label="Password"
                  type="password"
                  id="password"
                  autoComplete="current-password"
                  helperText={error?.message}
                />
              )}
            />

            <Button
              type="submit"
              fullWidth
              variant="contained"
              color="primary"
              className={classes.submit}
            >
              {props.isSignIn ? "Sign In" : "Sign Up"}
            </Button>
          </form>

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
