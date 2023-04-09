package com.noticias.domain.service;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;
import org.springframework.web.reactive.function.client.WebClient;
import org.springframework.web.util.UriUtils;

import com.noticias.domain.client.NewsResponse;

import reactor.core.publisher.Mono;

@Service
public class NewsService {
    @Value("${news.api.key}")
    private String apiKey;

    public Mono<NewsResponse> getNews(String q) {
        String encodedQ = UriUtils.encodeQueryParam(q, "UTF-8");
        WebClient webClient = WebClient.create("https://newsapi.org/v2/everything?apiKey=" + apiKey);
        Mono<NewsResponse> mono = webClient.get()
                                           .uri(builder -> builder.queryParam("q", encodedQ)
                                           .build())
                                           .retrieve()
                                           .bodyToMono(NewsResponse.class);
        return mono;
    }
}
