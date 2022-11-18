import React from "react";
import style from "./Footer.module.scss";
import ContactForm from "./ContactForm/ContactForm";

const Footer = () => {
  return (
    <div className={style.wrapper}>
      <ContactForm className={style.sova} />
    </div>
  );
};

export default Footer;
