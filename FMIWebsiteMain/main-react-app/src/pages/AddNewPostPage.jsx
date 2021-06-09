import React, { useState } from "react";
import { Link } from "react-router-dom";
import { Layout, Breadcrumb, Typography, Input, message, Button } from "antd";

const { Content } = Layout;

export const AddNewPostPage = (props) => {
  const [titleValue, setTitleValue] = useState("");
  const [bodyValue, setBodyValue] = useState("");
  const [titleValidation, setTitleValidation] = useState(false);
  const [bodyValidation, setBodyValidation] = useState(false);

  const loadError = (mes) => message.error(mes);

  const validationHandle = () => {
    if (titleValue === "") {
      setTitleValidation(true);
    } else {
      setTitleValidation(false);
    }
    if (bodyValue === "") {
      setBodyValidation(true);
    } else {
      setBodyValidation(false);
    }
  };

  return (
    <Content style={{ padding: "0 50px" }}>
      <Breadcrumb style={{ margin: "16px 0" }}>
        <Breadcrumb.Item>
          <Link to="/">Глввная</Link>
        </Breadcrumb.Item>
        <Breadcrumb.Item>
          <Link to="/">Новости</Link>
        </Breadcrumb.Item>
        <Breadcrumb.Item>Добавить</Breadcrumb.Item>
      </Breadcrumb>
      <div style={{ width: "60%" }}>
        <Typography.Title>Добавить новую публикацию</Typography.Title>

        <Typography.Title level={4}>Заголовок</Typography.Title>
        {titleValidation && (
          <>
            <Typography.Text type="danger">*Обязательное поле</Typography.Text>
            <br />
          </>
        )}
        <Input
          placeholder="Введите заголовок поста"
          value={titleValue}
          onChange={(e) => setTitleValue(e.target.value)}
          size="large"
          className="mb-15"
        />

        <Typography.Title level={4}>Текст</Typography.Title>
        {bodyValidation && (
          <>
            <Typography.Text type="danger">*Обязательное поле</Typography.Text>
            <br />
          </>
        )}
        <Input.TextArea
          placeholder="Введите текст поста"
          value={bodyValue}
          onChange={(e) => setBodyValue(e.target.value)}
          className="mb-15"
          autoSize={false}
          rows={10}
        />

        <Button size="large" type="primary" onClick={validationHandle}>
          Опубликовать
        </Button>
      </div>
    </Content>
  );
};
