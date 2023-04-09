package com.noticias.domain.model;

import java.util.UUID;

import org.springframework.data.neo4j.core.schema.GeneratedValue;
import org.springframework.data.neo4j.core.schema.Id;
import org.springframework.data.neo4j.core.schema.Node;

import lombok.Builder;

@Node("Tag")
public record Tag( 
    @Id  
    @GeneratedValue 
    UUID tagId,
    String name) {

    @Builder(toBuilder= true)
    public Tag{};
}
