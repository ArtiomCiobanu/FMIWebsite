import React from "react";
import { Card, Alert, Typography } from "antd";

export const Posts = ({ posts }) => {
  if (posts) {
    return (
      <div
        style={{
          width: "100%",
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
        }}
      >
        {posts.map((post, index) => {
          return (
            <Card
              key={`${index + post.title}`}
              title={
                <Typography.Title level={4}>{post.title}</Typography.Title>
              }
              extra={<a href="#">Читать</a>}
              style={{ width: "70%", marginBottom: "20px" }}
            >
              <span className="post-body-text">{post.body}</span>
            </Card>
          );
        })}
      </div>
    );
  } else {
    return (
      <Alert
        message="Внимание"
        description="Контент доступен только авторизованным пользователям"
        type="warning"
      />
    );
  }
};
