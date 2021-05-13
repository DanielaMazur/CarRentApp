import { TextField, Button } from "@material-ui/core";
import { useForm, Controller } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";

import { User } from "types";

import { useStyles } from "./sign-in-form.styles";

const SignInFormSchema = yup.object().shape({
  email: yup.string().email().required("Email is required"),
  password: yup.string().required("Password is required").min(8),
});

export type SignInFormProps = {
  handleFormSubmit: (credentials: User.SignInUser) => void;
};

const SignInForm = (props: SignInFormProps) => {
  const classes = useStyles();

  const { handleSubmit, control } = useForm<User.SignInUser>({
    resolver: yupResolver(SignInFormSchema),
    defaultValues: {
      email: "",
      password: "",
    },
  });

  return (
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
            required
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
        Sign In
      </Button>
    </form>
  );
};

export { SignInForm };
