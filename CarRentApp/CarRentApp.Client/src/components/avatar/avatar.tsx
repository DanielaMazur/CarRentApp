import { Avatar as MUIAvatar } from "@material-ui/core";

import { stringToColour } from "../../utils/text.utils";

import { useStyles } from "./avatar.styles";

export type AvatarProps = {
  name: string;
  shortName?: string;
};

const Avatar = (props: AvatarProps) => {
  const classes = useStyles({
    avatarColor: stringToColour(props.name ?? props.shortName),
  });

  const getAvatarName = (name: string) => {
    let avatarName = "";

    if (name == null) {
      return "";
    }

    name.split(" ").forEach((word) => (avatarName += word[0].toUpperCase()));

    return avatarName;
  };

  return (
    <MUIAvatar className={classes.avatar}>
      {props.name ? getAvatarName(props.name) : props.shortName?.slice(0, 3)}
    </MUIAvatar>
  );
};

export { Avatar };
