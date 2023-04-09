package com.noticias.domain.repository;

import java.util.UUID;

import org.springframework.data.neo4j.repository.ReactiveNeo4jRepository;
import org.springframework.data.neo4j.repository.config.EnableReactiveNeo4jRepositories;

import com.noticias.domain.model.User;

import reactor.core.publisher.Mono;

@EnableReactiveNeo4jRepositories
public interface UserRepository extends ReactiveNeo4jRepository<User,UUID>{

    Mono<User> findByEmail(String email);
    
}
