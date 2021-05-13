import { TextField, Button } from "@material-ui/core";
import { useForm, Controller } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";

import { Account } from "types";

import { useStyles } from "./sign-up-form.styles";

const SignUpFormSchema = yup.object().shape({
  firstName: yup.string().required("First Name is required"),
  lastName: yup.string().required("Last Name is required"),
  email: yup.string().email().required("Email is required"),
  password: yup.string().required("Password is required").min(8),
});

export type SignUpFormProps = {
  handleFormSubmit: (credentials: Account.Account) => void;
};

const SignUpForm = (props: SignUpFormProps) => {
  const classes = useStyles();

  const { handleSubmit, control } = useForm<Account.Account>({
    resolver: yupResolver(SignUpFormSchema),
    defaultValues: {
      firstName: "",
      lastName: "",
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
        name="firstName"
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
            id="firstName"
            label="First Name"
            fullWidth
            autoFocus
            required
            helperText={error?.message}
          />
        )}
      />

      <Controller
        control={control}
        name="lastName"
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
            id="lastName"
            label="Last Name"
            fullWidth
            autoFocus
            required
            helperText={error?.message}
          />
        )}
      />

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
            required
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
        Sign Up
      </Button>
    </form>
  );
};

export { SignUpForm };
