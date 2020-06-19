import { NgModule } from '@angular/core';
import { BlogComponent } from './blog.component';
import { BlogSidebarComponent } from './blog-sidebar/blog-sidebar.component';
import { BlogPostDetailComponent } from './blog-posts/blog-post-detail/blog-post-detail.component';
import { BlogCategoryDescriptionComponent } from './blog-category-description/blog-category-description.component';
import { BlogPostItemComponent } from './blog-posts/blog-post-list/blog-post-item/blog-post-item.component';
import { BlogPostListComponent } from './blog-posts/blog-post-list/blog-post-list.component';
import { BlogPostsComponent } from './blog-posts/blog-posts.component';
import { BlogPostCommentComponent } from './blog-posts/blog-post-detail/blog-post-comment/blog-post-comment.component';
import { BlogPostCommentListComponent } from './blog-posts/blog-post-detail/blog-post-comment/blog-post-comment-list/blog-post-comment-list.component';
import { BlogPostCommentItemComponent } from './blog-posts/blog-post-detail/blog-post-comment/blog-post-comment-list/blog-post-comment-item/blog-post-comment-item.component';
import { BlogPostLeaveCommentComponent } from './blog-posts/blog-post-detail/blog-post-comment/blog-post-leave-comment/blog-post-leave-comment.component';
import { BlogPostContentComponent } from './blog-posts/blog-post-detail/blog-post-content/blog-post-content.component';
import { SharedModule } from '../shared/shared.module';
import { BlogRoutingModule } from './blog-routing.module';


@NgModule({
    declarations: [
        BlogComponent,
        BlogSidebarComponent,
        BlogPostDetailComponent,
        BlogCategoryDescriptionComponent,
        BlogPostDetailComponent,
        BlogPostItemComponent,
        BlogPostListComponent,
        BlogPostsComponent,
        BlogPostCommentComponent,
        BlogPostCommentListComponent,
        BlogPostCommentItemComponent,
        BlogPostLeaveCommentComponent,
        BlogPostContentComponent
    ],
    imports: [
        BlogRoutingModule,
        SharedModule
    ]
})
export class CustomerModule { }