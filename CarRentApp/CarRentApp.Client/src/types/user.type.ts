export declare module User {
  export type User = {
    firstName: string;
    lastName: string;
    email: string;
    password: string;
  };

  export type SignInUser = {
    email: string;
    password: string;
  };

  export type UserToken = {
    accessToken: string;
  };
}
