import React from "react";
import style from "./ContactForm.module.scss";
import clsx from "clsx";
import Input from "../../../ui/Input/Input";
import Button from "../../../ui/Button/Button";

type ContactFormTypes = {
  className?: string;
};

const ContactForm: React.FC<ContactFormTypes> = ({ className }) => {
  return (
    <div className={clsx(style.wrapper, className)}>
      <div className={clsx(style.background, style.backgroundShadow)} />
      <div className={clsx(style.background, style.whiteBackground)}>
        <img src="/img/Layout/sova.png" alt="сова" className={style.sova} />
        <div className={style.helpWrapper}>
          <div className={style.help}>
            <h4>Помочь с выбором?</h4> <br />
            <p>
              Оставьте заявку и наши специалисты свяжутся с вами, ответят на все
              вопросы и подберут подходящий вариант обучения.
            </p>
          </div>
        </div>
        <div className={style.formWrapper}>
          <form action="" className={style.form}>
            <Input placeholder={"Ваше имя"} width={440} />
            <Input placeholder={"Ваше телефон"} className={style.marginTop20} />
            <Input placeholder={"Ваше e-mail"} className={style.marginTop20} />
            <p className={clsx(style.agree, style.marginTop20)}>
              Нажимая на кнопку, я соглашаюсь на обработку персональных данных и
              с правилами пользования Платформой
            </p>
            <Button
              text={"Отправить"}
              backgroundColor={"#F7941D"}
              color={"white"}
              className={style.marginTop20}
            />
          </form>
        </div>
      </div>
    </div>
  );
};

export default ContactForm;
