import React, { useState } from "react";
import { Layout, Button, Modal, Input, Typography, message } from "antd";

const { Header } = Layout;
const { Text } = Typography;

export const NavBar = () => {
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [emailValue, setEmailValue] = useState("");
  const [passwordValue, setPasswordValue] = useState("");
  const [emailValidation, setEmailValidation] = useState(false);
  const [passwordValidation, setPasswordValidation] = useState(false);

  const validationHandle = () => {
    if (emailValue === "") {
      setEmailValidation(true);
    } else {
      setEmailValidation(false);
    }
    if (passwordValue === "") {
      setPasswordValidation(true);
    } else {
      setPasswordValidation(false);
    }
  };

  return (
    <Header
      style={{
        display: "flex",
        alignItems: "center",
        justifyContent: "space-between",
      }}
    >
      <div className="logo" />
      <Button
        type="primary"
        size="large"
        onClick={() => setIsModalVisible(true)}
      >
        Войти
      </Button>
      <Modal
        title="FMI Student"
        visible={isModalVisible}
        onCancel={() => setIsModalVisible(false)}
        footer={[
          <Button key="enter" type="primary" onClick={validationHandle}>
            Войти
          </Button>,
          <span className="mr-8">или</span>,
          <Button key="register" className="mr-8" onClick={validationHandle}>
            Зарегистрироваться
          </Button>,
        ]}
      >
        <Text>Email</Text>
        <Input
          value={emailValue}
          placeholder="Enter email"
          onChange={(e) => setEmailValue(e.target.value)}
        />
        {emailValidation && (
          <>
            <Typography.Text type="danger">*Enter email</Typography.Text>
            <br />
          </>
        )}
        <Text>Password</Text>
        <Input.Password
          value={passwordValue}
          placeholder="Enter password"
          onChange={(e) => setPasswordValue(e.target.value)}
        />
        {passwordValidation && (
          <>
            <Typography.Text type="danger">*Enter password</Typography.Text>
            <br />
          </>
        )}
      </Modal>
    </Header>
  );
};
