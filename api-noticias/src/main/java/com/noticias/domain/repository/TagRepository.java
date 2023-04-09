package com.noticias.domain.repository;

import java.util.UUID;

import org.springframework.data.neo4j.repository.ReactiveNeo4jRepository;
import org.springframework.data.neo4j.repository.config.EnableReactiveNeo4jRepositories;
import org.springframework.data.neo4j.repository.query.Query;
import org.springframework.data.repository.query.Param;

import com.noticias.domain.model.Tag;

import reactor.core.publisher.Mono;

@EnableReactiveNeo4jRepositories
public interface TagRepository extends ReactiveNeo4jRepository<Tag, UUID> {

    @Query("MERGE (t:Tag {name: lower($name})) RETURN t")
    Mono<Tag> save(@Param("name")String name);
    
}
