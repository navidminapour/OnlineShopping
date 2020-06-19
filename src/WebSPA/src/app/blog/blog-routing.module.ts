import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BlogPostsComponent } from './blog-posts/blog-posts.component';
import { BlogPostDetailComponent } from './blog-posts/blog-post-detail/blog-post-detail.component';

const routes: Routes = [
    { path: '', component: BlogPostsComponent },
    { path: 'posts', component: BlogPostsComponent },
    { path: 'posts/:id', component: BlogPostDetailComponent }
];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class BlogRoutingModule { }