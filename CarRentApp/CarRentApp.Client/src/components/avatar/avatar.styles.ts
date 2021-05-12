import { makeStyles } from "@material-ui/core/styles";

export type AvatarStylesProps = {
  avatarColor: string;
};

const useStyles = makeStyles(() => ({
  avatar: {
    backgroundColor: (props: AvatarStylesProps) => props.avatarColor,
  },
}));

export { useStyles };
