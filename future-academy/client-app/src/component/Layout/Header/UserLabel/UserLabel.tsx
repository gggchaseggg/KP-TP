import React from 'react';
import style from "./UserLabel.module.scss";
import PATHS from "../../../../data/paths";
import ProfileIcon from "../../../SvgIcons/ProfileIcon";
import {Link} from "react-router-dom";
import {useAppSelector} from "../../../../redux/hooks";

const UserLabel = () => {
  const user = useAppSelector(state => state.user);

  return (
    <>
      <Link to={PATHS.LOGIN}>
        <ProfileIcon className={style.icon}/>
        <span>Войти</span>
      </Link>
    </>
  );
};

export default UserLabel;