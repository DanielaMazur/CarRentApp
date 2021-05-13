export declare module Account {
  export type Account = {
    firstName: string;
    lastName: string;
    email: string;
    password: string;
  };

  export type SignInAccount = {
    email: string;
    password: string;
  };

  export type AccountToken = {
    accessToken: string;
  };
}
