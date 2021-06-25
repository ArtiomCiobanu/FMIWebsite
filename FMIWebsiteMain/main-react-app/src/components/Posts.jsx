import React from "react";
import { Link } from "react-router-dom";
import { Card, Typography } from "antd";

export const Posts = (props) => {
  return (
    <div
      style={{
        width: "100%",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
      }}
    >
      {props.posts.map((post, index) => {
        return (
          <Card
            key={`${index + post.title}`}
            title={
              <Typography.Title className="title-header" level={4}>
                {post.title}
              </Typography.Title>
            }
            extra={<Link to={`/posts/${post.id}`}>Читать</Link>}
            className="post-card"
          >
            <span className="post-body-text">{post.content}</span>
          </Card>
        );
      })}
    </div>
  );
};
